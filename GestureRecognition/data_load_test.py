from Preprocessing.data_loader import Loader

path = "./Data/Processed/data.json"
loader = Loader(path)
train, test = loader.get_gestures()

print(len(train))
print(len(test))

for e in test:
    print(e[1])
    print(e[0].shape)



