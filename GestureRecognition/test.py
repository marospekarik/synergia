from random import randint
import numpy as np
import tensorflow as tf

from Preprocessing.data_generator import Generator
from Models.synergia_classifier import SynergiaClassifier
from Models.CustomSchedule import CustomSchedule


path = "./Data/processed.json"
generator = Generator(path)

generator.load_data()

loss_object = tf.keras.losses.SparseCategoricalCrossentropy(from_logits=True, reduction='none') 
learning_rate = CustomSchedule(256)
optimizer = tf.keras.optimizers.Adam(learning_rate, beta_1=0.9, beta_2=0.98, epsilon=1e-9)
model = SynergiaClassifier(3, [1,3,1], 256, 2, 3, 3, 256, 5)

# @tf.function
def train_step(x,y):
    with tf.GradientTape() as tape:
        predictions = model(x)
        loss = loss_object(y, predictions)
        print(loss)

    gradients = tape.gradient(loss, model.trainable_variables)
    optimizer.apply_gradients(zip(gradients, model.trainable_variables))
   
def train():
    EPOCHS = 2
    train_loss = tf.keras.metrics.Mean(name='train_loss')
    train_accuracy = tf.keras.metrics.SparseCategoricalAccuracy(name='train_accuracy')

    train_loss.reset_states()
    train_accuracy.reset_states()

    batches = next(generator.get_training_batches(number_of_batches=100, batch_size=32))
    for (batch_idx, (x,y)) in enumerate(batches):
        x = tf.constant(x, dtype=tf.float32)
        y = tf.constant(y, dtype=tf.int32)
        train_step(x,y)       

train()