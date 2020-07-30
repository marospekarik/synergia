import tensorflow as tf

class Convolution_Block(tf.keras.layers.Layer):
    def __init__(self, dims, filters, idx):
        super(Convolution_Block, self).__init__()

        self._cnn_layers = [tf.keras.layers.Conv2D(filters, dim, padding="same", activation="relu", use_bias="true", name=f"res{idx}_cnn{i}") 
            for i,dim in enumerate(dims)]
        
        self._bn_layer = [tf.keras.layers.BatchNormalization() for _ in dims]
        self._activation = tf.keras.layers.Activation("relu", name=f"res{idx}-relu")

    def call(self, x):
        resudiual_connection = x
        for cnn_layer, bn_layer in zip(self._cnn_layers, self._bn_layer):
            x = cnn_layer(x)
            x = bn_layer(x)
        x += resudiual_connection
        x = self._activation(x)
        return x
