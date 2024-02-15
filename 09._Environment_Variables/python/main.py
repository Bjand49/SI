from dotenv import load_dotenv, dotenv_values
import os

values = dotenv_values()
print(values)
load_dotenv()
print(os.getenv("BANDEORD"))