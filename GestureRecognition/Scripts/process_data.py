import numpy as np
import json 
import os
import sys

output = "./Data/Processed/data.json"
path = "./Data"
classes = ["Attract", "Clap", "Repulsion"]
joints = ["RightShoulder", "RightElbow", "RightWrist", "LeftShoulder", "LeftElbow", "LeftWrist"]

samples = []
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
        samples.append({
            "data": sample_data,
            "label":c.lower()
        })
  
with open(output, 'w') as f:
    json.dump(samples, f)           

# #process each filepath
# for i,filepath in enumerate(all_file_paths):
#     with open(filepath) as f:
#         data = json.load(f)
#     result = []


# sys.exit()



# with open(filepath) as f:
#     data = json.load(f)

# result = []
# time_step = 0
# time_step_data = []
# for element in data:

#     obj = {
#         "x":element["x"],
#         "y":element["y"],
#         "z":element["z"]
#         # "joint":element["joint"]
#     }

#     time_step_data.append(obj)

#     if element["joint"] == "LeftAnkle":
#         result.append(time_step_data)
#         time_step_data = []
#         time_step += 1

# data_example = {
#     "skeleton":result,
#     "label":0
# }

# data_examples = [data_example]

# with open(output, 'w') as f:
#     json.dump(data_examples, f)

