using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FileExplorerWPF
{
    class ActivityLogContent
    {

        public void AddActivity(Activity activity)
        {

            if (!File.Exists("ActivityLog.xml"))
            {
                List<Activity> activities = new List<Activity>();
                activities.Add(activity);
                XmlSerializer xs = new XmlSerializer(activities.GetType());
                FileStream fs = new FileStream("ActivityLog.xml", FileMode.Create);
                xs.Serialize(fs, activities);
                fs.Close();
            }
            else
            {
                List<Activity> user = RetriveData();
                user.Add(activity);
                FileStream fs = new FileStream("ActivityLog.xml", FileMode.Create);
                XmlSerializer xs = new XmlSerializer(user.GetType());
                xs.Serialize(fs, user);
                fs.Close();

            }

        }
        public List<Activity> RetriveData()
        {
            if (File.Exists("ActivityLog.xml"))
            {
                XmlRootAttribute root = new XmlRootAttribute();
                root.ElementName = "ArrayOfActivity";
                root.IsNullable = true;
                List<Activity> activities = new List<Activity>();
                XmlSerializer xs = new XmlSerializer(activities.GetType(), root);
                FileStream fs = new FileStream("ActivityLog.xml", FileMode.Open);
                activities = (List<Activity>)xs.Deserialize(fs);
                fs.Close();
                return activities;
            }

            return new List<Activity>(0);
        }

    }
}
