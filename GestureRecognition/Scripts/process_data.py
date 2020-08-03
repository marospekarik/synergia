import numpy as np
import json 

output = "./Data/processed.json"
filepath = "./Data/raw.json"
with open(filepath) as f:
    data = json.load(f)

result = []
time_step = 0
time_step_data = []
for element in data:

    obj = {
        "x":element["x"],
        "y":element["y"],
        "z":element["z"]
        # "joint":element["joint"]
    }

    time_step_data.append(obj)

    if element["joint"] == "LeftAnkle":
        result.append(time_step_data)
        time_step_data = []
        time_step += 1

data_example = {
    "skeleton":result,
    "label":0
}

data_examples = [data_example]

with open(output, 'w') as f:
    json.dump(data_examples, f)

