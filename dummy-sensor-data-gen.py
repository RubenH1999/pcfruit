import random
import datetime
import json
import requests
import sys


class Meter:
    def __init__(self, label, **kwargs):
        self.label = label
        data = kwargs
        self.analog = data['analog']
        self.voltage = data['voltage']
        self.resistance = data['resistance']

    def get_json(self):
        return {
            'label': self.label,
            'analog': self.analog,
            'voltage': self.voltage,
            'resistance': self.resistance
        }
    
    def __str__(self):
        return self.get_json()

class DendroMeter(Meter):
    def __init__(self, label, **kwargs):
        super().__init__(label, **kwargs)
        self.dist = kwargs['dist']

    def get_json(self):
        json = super().get_json()
        json['distance'] = self.dist
        return json


class TempMeter(Meter):
    def __init__(self, label, **kwargs):
        super().__init__(label, **kwargs)
        self.temp = kwargs['temp']


    def get_json(self):
        json = super().get_json()
        json['temperature'] = self.temp
        return json


class HumidityMeter(Meter):
    def __init__(self, label, **kwargs):
        super().__init__(label, **kwargs)
        self.humidity = kwargs['humidity']

    def get_json(self):
        json = super().get_json()
        json['humidity'] = self.humidity
        return json


def rnd(min = 1, max = 5):
    return random.randint(min, max)

def randomize_data(moduleName = None, timeOffset = 0):
    data = {
        'logger': moduleName if moduleName else "Log00{}".format(random.randint(0, 999)),
        'dateTime': (datetime.datetime.now() + datetime.timedelta(minutes=int(timeOffset))).strftime("%Y-%m-%d %H:%M:%S"),
        'sensors': []
    }
    
    for label in ['L', 'K', 'J', 'I', 'F', 'E']:
        data['sensors'].append(
            DendroMeter(
                label, 
                analog=rnd(),
                voltage=rnd(),
                resistance=rnd(),
                dist=random.randint(5, 20)
            ).get_json()
        )
    
    for label in ['A', 'B', 'C']:
        data['sensors'].append(
            TempMeter(
                label, 
                analog=rnd(), 
                voltage=rnd(), 
                resistance=rnd(),
                temp=rnd(10, 30)
            ).get_json()
        )

    for label in ['X', 'Y', 'Z']:
        data['sensors'].append(
            HumidityMeter(
                label, 
                analog=rnd(), 
                voltage=rnd(), 
                resistance=rnd(),
                humidity=rnd()
            ).get_json()
        )

    return data

# usage: python script.py <api url> <module>

# read module from args
moduleName = None
if len(sys.argv) >= 3:
    moduleName = sys.argv[2]

    
timeOffset = 0
if len(sys.argv) == 4:
    timeOffset = sys.argv[3]

data = randomize_data(moduleName, timeOffset)
print("sending: " + json.dumps(data))

url = "http://localhost:61955/api/measurements"
if len(sys.argv) > 1:
    url = sys.argv[1]

r = requests.post(url, json=data)
print("status: " + str(r.status_code))
print("response: " + r.text)
