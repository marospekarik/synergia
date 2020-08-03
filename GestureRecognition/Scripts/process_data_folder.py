import numpy as np
import json 
import os

directory = '../Data/Attract'

for filename in os.listdir(directory):
    if filename.endswith("_processed.json"):
        print('skipping...')
    elif filename.endswith(".json"):
        filepath = '{}/{}'.format(directory, filename)
        output = '{}/{}_processed.json'.format(directory, os.path.splitext(filename)[0])
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

            if element["joint"] == "RightWrist" or element["joint"] == "LeftWrist":
                result.append(time_step_data)
                time_step_data = []
                time_step += 2

        data_example = {
            "skeleton":result,
            "label":2
        }

        data_examples = [data_example]

        with open(output, 'w') as f:
            json.dump(data_examples, f)
    else:
        continue

