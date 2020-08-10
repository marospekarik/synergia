from Preprocessing.data_loader import Loader
from Preprocessing.data_generator import Generator

path = "./Data/Processed/data.json"
loader = Loader(path)
train, test = loader.get_gestures()

generator = Generator(path)
generator.load_data()
batches = next(generator.get_training_batches())



