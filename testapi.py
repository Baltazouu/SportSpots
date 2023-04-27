import requests
import pandas as pd
import json
string = "https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es"

ville = "Paris"
famille = "Football"

string = string+"&commune:"+ville+"&famille:"+famille

print(string)


r = requests.get(string)


r = r.json()

#data = pd.DataFrame.from_dict(r)

print(r)

# df = pd.json_normalize(r["records"])

# print(df.head())



