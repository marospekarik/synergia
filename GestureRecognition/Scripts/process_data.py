import numpy as np
import json 
import os
import sys
from math import floor

output = "./Data/Processed/data.json"
path = "./Data"
classes = ["Attract", "Clap", "Repulsion"]
joints = ["RightShoulder", "RightElbow", "RightWrist", "LeftShoulder", "LeftElbow", "LeftWrist"]

samples = []
lens = []
for c in classes:
    class_path = f"{path}/{c}"
    file_paths = [f"{class_path}/{filepath}" for filepath in os.listdir(class_path) if "processed" not in filepath]
    print()
    print(f"- processing {c}")
    for i,file_path in enumerate(file_paths):
        print(f"-- processing file {i + 1}/ {len(file_paths)}")
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
        lens.append(len(sample_data))
        samples.append({
            "data": sample_data,
            "label":c.lower()
        })

samples = samples * 7

#pricess giberrish
file_path = "./Data/gibber3.json"

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

TIME_WINDOW_SIZE = floor(np.average(lens))
TIME_WINDOW_STRIDE = TIME_WINDOW_SIZE #no overlap (we have plenty of data)

for n in range(0, len(sample_data), TIME_WINDOW_STRIDE):
# for n in range(0, 40*TIME_WINDOW_STRIDE, TIME_WINDOW_STRIDE):
    if len(sample_data[n:n+TIME_WINDOW_STRIDE]) != TIME_WINDOW_STRIDE:
        continue
    samples.append({
        "data": sample_data[n:n+TIME_WINDOW_STRIDE],
        "label": "nothing"
    })

# end giberrish process

with open(output, 'w') as f:
    json.dump(samples, f)           

