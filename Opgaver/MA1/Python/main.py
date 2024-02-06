import xml.etree.ElementTree as ET
import json
import yaml
import pandas as pd


def loadXML():
    file = ET.parse('Files//me.xml')
    root = file.getroot()
    obj = me(
        root[0].text,
        root[1].text,
        root[2].text,
        {t.text for t in root[3].findall('*')}
    )
    obj.print()


def loadJSON():
    file = open('Files//me.json','r',encoding="utf-8").read()
    data = json.loads(file)
    obj = me(**data)
    obj.print()

def loadYAML():
    file = open('Files//me.yaml', 'r',encoding="utf-8").read()
    data = yaml.safe_load(file)
    obj = me(**data)
    obj.print()

def loadCSV():
    dataframe = pd.read_csv('Files//me.csv')
    data = dataframe.iloc[0]
    obj = me(
        data['FirstName'],
        data['LastName'],
        data['Email'],
        data['Hobbies'].split("'")
    )
    obj.print()

def loadText():
    file = open('Files//me.txt','r').read()
    data = file.split('\n')
    obj = me(
        data[0],
        data[1],
        data[2],
        data[3].split("'")
    )
    obj.print()

class me:
  def __init__(self, firstname, lastname,email,hobbies):
    self.firstname = firstname
    self.lastname = lastname
    self.email = email
    self.hobbies = hobbies

  def print(self):
    print(f"This is me. my name is {self.firstname} {self.lastname}, my Email is {self.email}, My hobbies involves {', '.join(self.hobbies)}")

loadJSON()
loadYAML()
loadCSV()
loadText()
loadXML()
