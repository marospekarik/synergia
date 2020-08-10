import tensorflow as tf
import sys

from Models.convolution_block import Convolution_Block
from Models.custom_bidirectional_lstm_block import Custom_Bidirectional_LSTM_Block

class SynergiaClassifier(tf.keras.Model):
    def __init__(self, cnn_blocks, cnn_block_dims, cnn_block_filters, mp_layer_idx, mp_layer_kernel, blstm_blocks, lstm_block_units, classes):
        super(SynergiaClassifier, self).__init__()

        assert mp_layer_idx <= cnn_blocks

        self._dim_cnn = tf.keras.layers.Conv1D(cnn_block_filters, kernel_size=1, padding="same", activation="relu", name=f"dimensionality-cnn")

        self._mp_layer_idx = mp_layer_idx
        self._mp_layer = tf.keras.layers.MaxPooling1D(pool_size=mp_layer_kernel, name="mp_layer")

        self._cnn_blocks = [Convolution_Block(cnn_block_dims, cnn_block_filters, i) for i in range(cnn_blocks)]

        self._blstm_blocks = [Custom_Bidirectional_LSTM_Block(lstm_block_units, i) for i in range(blstm_blocks)]
        self._fully_connected = tf.keras.layers.Dense(50, activation=tf.keras.activations.relu)
        self._softmax = tf.keras.layers.Dense(classes, activation=tf.keras.activations.softmax)
    
    def call(self, x):
        x = self._dim_cnn(x)
        x = self._call_cnn_blocks(x)
        x = self._call_blstm_blocks(x)
        x = self._fully_connected(x)
        x = self._softmax(x)
        return x

    def _call_cnn_blocks(self, x):
        for i, cnn_block in enumerate(self._cnn_blocks):
            x = cnn_block(x)

            if i == self._mp_layer_idx:
                x = self._mp_layer(x)
        return x

    def _call_blstm_blocks(self, x):
        for _, blstm_block in enumerate(self._blstm_blocks):
            x = blstm_block(x)
        return x
