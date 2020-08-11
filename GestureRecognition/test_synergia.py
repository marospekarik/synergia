import json
import time

from synergia import Synergia

with open("./Data/Attract/sample1.json") as f:
# with open("./Data/Clap/clap1.json") as f:    
    data = json.load(f)

synergia = Synergia("./TrainedModels/synergia_gesture_classifier.h5")

for i,e in enumerate(data):

    obj = {
        "x":data[i]["x"],
        "y":data[i]["y"],
        "z":data[i]["z"]
    }
    joint = data[i]["joint"]

    synergia.predict(obj, joint)
    # time.sleep(0.01)
print(synergia.predictions)