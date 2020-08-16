import yaml
import glob

files = glob.glob("../References/Altseed2.*.yml")

result = {}

for f in files:
    print("loading... {}".format(f))
    with open(f, "r", encoding="UTF8") as yml:
        src = yaml.load(yml)["items"][0]
    result[src["uid"]] = src["children"]

with open("../ReferenceExtract.yml", "w", encoding="UTF8") as output:
    output.write(yaml.dump(result))
