import numpy as np
import json 
import os
import sys
from math import floor

def get_obj(element):
    return {
        "x":element["x"],
        "y":element["y"],
        "z":element["z"],
        #"joint":element["joint"]
    }    

def process_file(file_path, label, samples, factor):

    with open(file_path) as f:
        data = json.load(f)
    
    WINDOW_SIZE = 20
    WINDOW_STRIDE = int(20 / factor)

    sample_data = []
    time_step_data = []
    for element in data:
        obj = get_obj(element)
        if element["joint"] in joints:
            time_step_data.append(obj)
        if element["joint"] == "LeftAnkle": #last joint in every measurement indicates next time step
            sample_data.append(time_step_data)
            time_step_data = []   
    for n in range(0, len(sample_data), WINDOW_STRIDE):
        if len(sample_data[n:n+WINDOW_SIZE]) < WINDOW_SIZE:
            continue
        samples.append({
            "data": sample_data[n:n+WINDOW_SIZE],
            "label": label.lower()
        })
    return samples

samples = []
file_paths = ["./Data/Attraction.json", "./Data/Clapping.json", "./Data/Nothing.json", "./Data/Repulsing.json"]
labels = ["Attract", "Clap", "Nothing", "Repulsion"]
output = "./Data/Processed/long_data.json"
joints = ["RightShoulder", "RightElbow", "RightWrist", "LeftShoulder", "LeftElbow", "LeftWrist"]
factors = [10,10,4,10]

for i,_ in enumerate(file_paths):
    old_samples_len = len(samples)
    samples = process_file(file_paths[i], labels[i], samples, factors[i])
    print(f"Added {len(samples) - old_samples_len} samples of {labels[i]}")

with open(output, 'w') as f:
    json.dump(samples, f)           

