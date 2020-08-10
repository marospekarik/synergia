import tensorflow as tf

class TestModel(tf.keras.Model):
    def __init__(self):
        super(TestModel, self).__init__()

        self._forward_lstm = tf.keras.layers.LSTM(50, return_sequences=True, name=f"lstm-forward")

    def call(self, x):
        return self._forward_lstm(x)