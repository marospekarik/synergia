from queue import Queue
import tensorflow as tf 
import numpy as np
import sys

from datetime import datetime

from Models.synergia_classifier import SynergiaClassifier

class Synergia:
    def __init__(self, model_filename, buffer_size=17, min_buffer_size=7):
        self._model = self._init_model(model_filename)

        self._expected_joints = ["RightShoulder", "RightElbow", "RightWrist", "LeftShoulder", "LeftElbow", "LeftWrist"]
        self._expected_pos = 0
        self._current_time_step = []
        self._buffer = Queue(maxsize=buffer_size)
        self._min_buffer_size = min_buffer_size

        # self.predictions = []
        self._latest_label = "nothing"
        self._latest_confidence = -1

    def _init_model(self, filename):
        model = SynergiaClassifier(
            cnn_blocks=5,
            cnn_block_dims=[1,3,1],
            cnn_block_filters=128, 
            mp_layer_idx=2, 
            mp_layer_kernel=2, 
            blstm_blocks=3, 
            lstm_block_units=128, 
            classes=4)
        

        model(tf.random.uniform([1,10,18])) #build model with random stuff
        model.load_weights(filename)      
        return model

    def _process_buffer(self):
        x = []
        for timestep in self._buffer.queue:
            time_step_tensor = []
            for joint in timestep:
                joint_tensor = [joint["x"],joint["y"],joint["z"]]
                time_step_tensor.append(joint_tensor)
            x.append(time_step_tensor)
        return np.array([x])

    def predict(self, obj, joint):
        if joint not in self._expected_joints: #skip joint you dont care about
            # print(f"- got {joint} skipping...")
            return self._latest_label, self._latest_confidence
        
        if joint != self._expected_joints[self._expected_pos]: #received desired joint, but there was a skip
            # print(f"- got {joint}, expected {self._expected_joints[self._expected_pos]}, reseting timestep...")
            self._expected_pos = 0
            self._current_time_step = []
            return self._latest_label, self._latest_confidence      

        self._current_time_step.append({
                "x":obj["x"],
                "y":obj["y"],
                "z":obj["z"]
        })

        if self._expected_pos == len(self._expected_joints) - 1:
            #time step is filled with joints -> add to queue
            self._expected_pos = 0

            if self._buffer.full():
                # print(f"-- queue is full - removeing oldest obj...")
                self._buffer.get()
            self._buffer.put(self._current_time_step)
            # print(f"- got {joint}, adding to queue, queue obj size:{len(self._current_time_step)}, queue size:{self._buffer.qsize()}")
            self._current_time_step = []
        else:
            # print(f"- got {joint}, seeking next time step... ")
            self._expected_pos += 1
            return self._latest_label, self._latest_confidence
        
        #time step added to the buffer -> process and predict
        if self._buffer.qsize() < self._min_buffer_size:
            return self._latest_label, self._latest_confidence
            # print("- queue is too small, skipping...")
        else:
            # print("- predicting...")
            start_time = datetime.now()
            x = self._process_buffer()
            x = tf.reshape(x, [x.shape[0], -1, 18])
            x = tf.constant(x, dtype=tf.float64)
            predictions = self._model(x)
            predictions_t = tf.transpose(predictions, perm=[1,0,2])
            predictions_last_ts = predictions_t[-1]
            y_pred = tf.math.argmax(predictions_last_ts, axis=1)
            y_pred = y_pred.numpy()[0]
            y_pred_confidence = tf.math.reduce_max(predictions_last_ts, axis=1).numpy()[0]

            label = self._get_label_from_idx(y_pred)
            end_time = datetime.now()
            print(f"Took: {end_time-start_time}")

            self._latest_label = label
            self._latest_confidence = y_pred_confidence
            # self.predictions.append(label)
            # print()
            # print(f"-- predicted {label} with confidence {y_pred_confidence}, distribution:{predictions_last_ts.numpy()}")
            return self._latest_label, self._latest_confidence


    def _get_label_from_idx(self, label_idx):
        return ["attract", "clap", "repulsion", "nothing"][label_idx]