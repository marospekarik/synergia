import numpy as np

from Preprocessing.data_loader import Loader

class Generator():
    def __init__(self, data_filepath) -> None:
        self._loader = Loader(data_filepath)
        self._train_idx = 0
        self._val_idx = 0

    def load_data(self) -> None:
        self._train_data, self._validation_data = self._loader.get_gestures()     

    def get_training_batches(self, number_of_batches=100, batch_size=32):
        while True:
            batches = []
            for _ in range(number_of_batches):
                batch = next(self.get_traning_batch(batch_size))
                batches.append(batch)
            yield batches

    def get_traning_batch(self, batch_size=10):

        while True:
            if self._train_idx + batch_size >= len(self._train_data):
                batch = self._train_data[self._train_idx:]
                self._train_idx = 0
                np.random.shuffle(self._train_data)
            else:
                batch = self._train_data[self._train_idx:self._train_idx + batch_size]
                self._train_idx += batch_size

            max_len = self._get_max_timestep_length(batch)
            x,y = self._process_batch(batch, max_len)
            yield x,y
    
    def _process_batch(self, batch, max_len):
        x = []
        y = []
        for example in batch:
            skeleton = example[0]    

            assert skeleton.ndim == 3 #ensure expected shape        
            pad = np.ones([max_len-skeleton.shape[0], skeleton.shape[1], skeleton.shape[2]]) * -1e9
            padded = np.append(skeleton,pad,axis=0)
            x.append(padded)
            y.append(example[1])
        
        return np.array(x), np.array(y)
            

    def _get_max_timestep_length(self, batch):
        max_time_step_length = -1
        for example in batch:
            if len(example[0]) > max_time_step_length:
                max_time_step_length = len(example[0])
        return max_time_step_length


        

