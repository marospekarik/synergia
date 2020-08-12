import numpy as np
import json 
import os
import sys

import numpy as np
import json 
import os
import sys

output = "./Data/Processed/data.json"
file_path = "./Data/gibber3.json"
joints = ["RightShoulder", "RightElbow", "RightWrist", "LeftShoulder", "LeftElbow", "LeftWrist"]

samples = []


with open(file_path) as f:
    data = json.load(f)
sample_data = []
time_step_data = []
for element in data:
    obj = {
        "x":element["x"],
        "y":element["y"],
        "z":element["z"],
        #"joint":element["joint"]
    }

    if element["joint"] in joints:
        time_step_data.append(obj)
    if element["joint"] == "LeftAnkle": #last joint in every measurement indicates next time step
        sample_data.append(time_step_data)
        time_step_data = []

TIME_WINDOW_SIZE = 27
TIME_WINDOW_STRIDE = 27

samples = []
for n in range(0, len(sample_data), TIME_WINDOW_STRIDE):
    if len(sample_data[n:n+TIME_WINDOW_STRIDE]) != TIME_WINDOW_STRIDE:
        continue
    samples.append({
        "data": sample_data[n:n+TIME_WINDOW_STRIDE],
        "label": "nothing"
    })

print(len(samples))



# samples.append({
#     "data": sample_data,
#     "label":c.lower()
# })
  
# with open(output, 'w') as f:
#     json.dump(samples, f)           

        