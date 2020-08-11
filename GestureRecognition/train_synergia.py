from random import randint
import numpy as np
import tensorflow as tf
import sys
from functools import reduce

from Preprocessing.data_generator import Generator
from Models.synergia_classifier import SynergiaClassifier
from Models.test_model import TestModel
from Models.CustomSchedule import CustomSchedule


path = "./Data/Processed/data.json"
generator = Generator(path)

generator.load_data()

EPOCHS = 10000
BATCH_SIZE = 32
VAL_BATCH_SIZE = 5

D_MODEL = 64
LSTM_BLOCKS = 1
CNN_BLOCKS = 3
CNN_BLOCK_DIMS = [1,3,1]
MP_KERNEL_SIZE = 3
MP_KERNEL_IDX = 2
CLASSES = ["attract", "clap", "repulsion"]

loss_object = tf.keras.losses.SparseCategoricalCrossentropy(from_logits=True, reduction='none') 
learning_rate = CustomSchedule(D_MODEL)
optimizer = tf.keras.optimizers.Adam(learning_rate, beta_1=0.9, beta_2=0.98, epsilon=1e-9)

model = SynergiaClassifier(
            cnn_blocks=CNN_BLOCKS,
            cnn_block_dims=CNN_BLOCK_DIMS,
            cnn_block_filters=D_MODEL, 
            mp_layer_idx=MP_KERNEL_IDX, 
            mp_layer_kernel=MP_KERNEL_SIZE, 
            blstm_blocks=LSTM_BLOCKS, 
            lstm_block_units=D_MODEL, 
            classes=len(CLASSES))

train_loss = tf.keras.metrics.Mean(name='train_loss')
train_accuracy = tf.keras.metrics.SparseCategoricalAccuracy(name='train_accuracy')

@tf.function
def train_step(x,y):
    with tf.GradientTape() as tape:
        predictions = model(x)

        predictions_t = tf.transpose(predictions, perm=[1,0,2])
        predictions_last_ts = predictions_t[-1]
        
        loss_ = loss_object(y, predictions_last_ts)
        loss = tf.reduce_mean(loss_)

    gradients = tape.gradient(loss, model.trainable_variables)
    
    # tf.print(y,output_stream="file://.y.out", summarize=1000000)       
    # tf.print(predictions_last_ts,output_stream="file://.y.out", summarize=1000000)   
    # tf.print(loss,output_stream="file://.y.out", summarize=1000000)           
    # tf.print("------",output_stream="file://.y.out", summarize=1000000)      

    optimizer.apply_gradients(zip(gradients, model.trainable_variables))
    train_loss(loss)
    train_accuracy(y, predictions_last_ts)

def validate():

    val_batches = generator.get_validation_batches(batch_size=VAL_BATCH_SIZE)
    correct = 0
    total = 0
    for (batch_idx, (x,y)) in enumerate(val_batches):
        
        x = tf.reshape(x, [x.shape[0], -1, 18])
        x = tf.constant(x, dtype=tf.float64)
        y = label_to_int(y)
        y = tf.constant(y, dtype=tf.int64)

        predictions = model(x)
        predictions_t = tf.transpose(predictions, perm=[1,0,2])
        predictions_last_ts = predictions_t[-1]
        
        y_pred = tf.math.argmax(predictions_last_ts, axis=1)
        assert y_pred.shape == y.shape
        
        eq_tensor = tf.math.equal(y_pred, y)
        int_eq_tensor = tf.cast(eq_tensor, tf.int64)
        result = tf.reduce_sum(int_eq_tensor)
        correct += result.numpy()
        total += len(int_eq_tensor)
    
    return correct, total

def train():
   
    for epoch in range(EPOCHS):
        train_loss.reset_states()
        train_accuracy.reset_states()
        batches = next(generator.get_training_batches(number_of_batches=2, batch_size=BATCH_SIZE))

        for (batch_idx, (x,y)) in enumerate(batches):
            
            x = tf.reshape(x, [x.shape[0], -1, 18])
            x = tf.constant(x, dtype=tf.float64)

            y = label_to_int(y)
            y = tf.constant(y, dtype=tf.int32)

            train_step(x,y)  
        #     print (f'Epoch {epoch + 1} Batch {batch_idx} Loss {train_loss.result():.4f} Accuracy {train_accuracy.result():.4f}', end="\r")    
        # print()
        loss = train_loss.result()
        acc = train_accuracy.result()
        
        val_correct, val_total = validate()
        print (f'Epoch {epoch + 1} Train loss {loss:.4f} Train accuracy {acc:.4f}, Validation: {val_correct}/{val_total}') 

def label_to_int(labels):

    labels_int = []
    for label in labels:
        label_int = [i for i,lbl_class in enumerate(CLASSES) if lbl_class == label]
        labels_int.extend(label_int)
    return labels_int
    
train()