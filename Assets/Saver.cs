using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Assets
{
    class Saver
    {

        public void save(List<Match> list)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savefile.gd");
            bf.Serialize(file, list);
            file.Close();
        }

        public List<Match> load()
        {
            if (File.Exists(Application.persistentDataPath + "/savefile.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savefile.gd", FileMode.Open);
                List<Match> output = (List<Match>)bf.Deserialize(file);
                file.Close();
                return output;
            }
            else
            {
                return new List<Match>();
            }
        }
    }
}
