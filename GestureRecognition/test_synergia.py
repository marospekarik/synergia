import json
import time
import argparse
import random

from pythonosc import dispatcher
from pythonosc import osc_server

from synergia import Synergia
synergia = Synergia("./TrainedModels/synergia_gesture_classifier_long_3LSTM_5CNN.h5")

with open("./Data/Attract/sample1.json") as f:
# with open("./Data/Clap/clap1.json") as f:    
    data = json.load(f)

def handleMessage(address, arg1, arg2, arg3, _):
    obj = {
        "x":arg1,
        "y":arg2,
        "z":arg3
    }
    prediction, confidence = synergia.predict(obj, address[1:])
    print(f"{prediction}, {confidence}")
    # print(f"[{address[1:]}], {arg2}")

# for i,e in enumerate(data):

#     obj = {
#         "x":data[i]["x"],
#         "y":data[i]["y"],
#         "z":data[i]["z"]
#     }
#     joint = data[i]["joint"]

#     synergia.predict(obj, joint)
#     # time.sleep(0.01)


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--ip",
        default="127.0.0.1", help="The ip to listen on")
    parser.add_argument("--port",
        type=int, default=7403, help="The port to listen on")
    args = parser.parse_args()

    dispatcher = dispatcher.Dispatcher()
    dispatcher.map("*", handleMessage)

    server = osc_server.ThreadingOSCUDPServer(
        (args.ip, args.port), dispatcher)
    print("Serving on {}".format(server.server_address))
    server.serve_forever()