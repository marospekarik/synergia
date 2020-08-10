import tensorflow as tf

class Custom_Bidirectional_LSTM_Block(tf.keras.layers.Layer):
    def __init__(self, units, idx):
        super(Custom_Bidirectional_LSTM_Block, self).__init__()

        self._forward_lstm = tf.keras.layers.LSTM(units, return_sequences=True, name=f"lstm{idx}-forward")
        self._backward_lstm = tf.keras.layers.LSTM(units, return_sequences=True, go_backwards="True", name=f"lstm{idx}-backward")
        self._addition = tf.keras.layers.Add(name=f"lstm{idx}-add")
    
    def call(self, x):
        x_forward = self._forward_lstm(x)
        x_backward = self._backward_lstm(x)
        x = self._addition([x_forward, x_backward])
        return x