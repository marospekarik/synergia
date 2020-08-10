import json
from math import ceil
import numpy as np
from random import randint
import os

class Loader():
    def __init__(self, filepath, split = [0.8, 0.2]) -> None:
        self._filepath = filepath
        assert split[0] + split[1] == 1
        self._train_split = split[0]
        self._validation_split = split[1]

    def get_gestures(self):

        gestures = self._load_gestures_from_file(self._filepath) 
        preprocessed_gestures = self._get_preprocessed_gestures(gestures)
        shuffled_gestures = self._get_shuffled_gestures(preprocessed_gestures)

        train = self._get_train_gestures(shuffled_gestures)
        validation = self._get_validation_gestures(shuffled_gestures)
        return train, validation     
        
    def _get_train_gestures(self, shuffled_gestures):
        split_point = ceil(len(shuffled_gestures) * self._train_split)
        return shuffled_gestures[:split_point]

    def _get_validation_gestures(self, shuffled_gestures):
        train_split_point = ceil(len(shuffled_gestures) * self._train_split)
        return shuffled_gestures[train_split_point:]

    def _get_shuffled_gestures(self, gestures):
        np.random.shuffle(gestures)
        return gestures

    def _get_preprocessed_gestures(self, genstures):
        data_tensor = []
        for example in genstures:
            skeleton = example["data"]
            x = []
            y = example["label"]
            for time_step in skeleton:
                time_step_tensor = []
                for joint in time_step:
                    joint_tensor = [joint["x"],joint["y"],joint["z"]]
                    time_step_tensor.append(joint_tensor)
                x.append(time_step_tensor)
            data_tensor.append((np.array(x),y))
        return data_tensor

    def _load_gestures_from_file(self, filepath):
        with open(filepath) as json_file:
            return json.load(json_file)
