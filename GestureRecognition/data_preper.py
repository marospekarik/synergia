import numpy as np

class DataPreper:
    def preprocess(self, data):
        data_tensor = []
        for example in data:
            skeleton = example["skeleton"]
            x = []
            y = example["label"]
            for time_step in skeleton:
                time_step_tensor = []
                for joint in time_step:
                    joint_tensor = [joint["x"],joint["y"],joint["z"]]
                    time_step_tensor.append(joint_tensor)
                x.append(time_step_tensor)
            data_tensor.append((x,y))

        data_tensor = np.array(data_tensor)
        np.random.shuffle(data_tensor)
        
        print(f"Processed data to shape: {data_tensor.shape}")
        return data_tensor
