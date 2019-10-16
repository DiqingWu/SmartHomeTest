using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    class AcAndroid
    {
        MQTT_Message MQTT_send;
        List<float> temp;
        int state = 0;
        int count = 0;
        string homeid;
        public AcAndroid(string homeid)
        {
            this.homeid = homeid;
            MQTT_send = SmartHomeController._apiManager.SendMQTT;
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\""+homeid+"\",\"Device\":\"heater 1\",\"Status\":\"0\"}");
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"0\"}");
        }
        public void UpdateInfo()
        {
            //state 0 idle
            //state 1 heater on
            //state 2 cooler on
            float temp =
                        SmartHomeController._databaseController.database.homes[homeid]._currentRoom.temp;
            float preTemp = SmartHomeController._databaseController.database.homes[homeid]._currentRoom.PreTemp;
            float PreTempFix = preTemp;
            count++;
                if (temp > PreTempFix)
                {
                    switch (state)
                    {
                        case 0:
                            // turn on cooler
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"1\"}");
                            state = 2;
                            break;
                        case 1:
                            // turn on cooler
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"1\"}");
                            // turn off heater
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"0\"}");
                            state = 2;
                            break;
                        case 2:
                            // do nothing
                            break;
                        default:
                            throw new Exception("AC error check state machine????");
                    }
                }
                else if (temp < preTemp)
                {
                    switch (state)
                    {
                        case 0:
                            // turn on heater
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"1\"}");
                            state = 1;
                            break;
                        case 1:
                            // do nothing
                            break;
                        case 2:
                            // turn on heater
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"1\"}");
                            // turn off cooler
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"0\"}");
                            state = 1;
                            break;
                        default:
                            throw new Exception("AC error check state machine????");
                    }
                }
                else
                {
                    switch (state)
                    {
                        case 0:
                            // do nothing
                            break;
                        case 1:
                            // turn off heater
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"0\"}");
                            state = 0;
                            break;
                        case 2:
                            // turn off cooler
                            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"0\"}");
                            state = 0;
                            break;
                        default:
                            throw new Exception("AC error check state machine????");
                    }
                }

            }


        }
    }

