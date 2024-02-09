using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDBOXMAUI.Model
{
    public class APILedbox
    {



        public const string CMD_INIT = "Init";
        public const string CMD_DISCONNECT = "Disconnect";
        public const string CMD_CLEAR = "Clear";
        public const string CMD_UPLOAD = "Upload";
        public const string CMD_UPLOADED = "Uploaded";
        public const string CMD_CHANGEWAITING = "ChangeWaiting";

        public const string CMD_SETSECTION = "SetSection";
        public const string CMD_SETSECTIONS = "SetSections";
        public const string CMD_HORN = "Horn";
        public const string CMD_SETLAYOUT = "SetLayout";
        public const string CMD_RELOADLAYOUT = "ReloadLayout";

        public const string CMD_SETPLAYLISTIMAGE = "SetPlaylistImage";
        public const string CMD_STOPPLAYLISTIMAGE = "StopPlaylistImage";
        public const string CMD_STARTPLAYLISTIMAGE = "StartPlaylistImage";
        public const string CMD_PAUSEPLAYLISTIMAGE = "PausePlaylistImage";
        public const string CMD_GETLISTPLAYLISTIMAGE = "GetListPlaylistImage";
        public const string CMD_UPLOADLISTPLAYLISTIMAGE = "UploadPlaylistImage";


        public const string CMD_SETPLAYLISTAUDIO = "SetPlaylistAudio";
        public const string CMD_STOPPLAYLISTAUDIO = "StopPlaylistAudio";
        public const string CMD_STARTPLAYLISTAUDIO = "StartPlaylistAudio";
        public const string CMD_PAUSEPLAYLISTAUDIO = "PausePlaylistAudio";
        public const string CMD_GETLISTPLAYLISTAUDIO = "GetListPlaylistAudio";
        public const string CMD_UPLOADLISTPLAYLISTAUDIO = "UploadPlaylistAudio";


        public const string CMD_STARTCUSTOMTEXT = "StartCustomText";
        public const string CMD_PAUSECUSTOMTEXT = "PauseCustomText";
        public const string CMD_STOPCUSTOMTEXT = "StopCustomText";


        public const string CMD_SETPRACTICE = "SetPractice";
        public const string CMD_STARTPRACTICE = "StartPractice";
        public const string CMD_STOPPRACTICE = "StopPractice";
        public const string CMD_PAUSEPRACTICE = "PausePractice";
        public const string CMD_GETLISTPRACTICE = "GetListPractice";
        public const string CMD_UPLOADPRACTICE = "UploadPractice";



        public const string CMD_SETCONFIG = "SetConfig";
        public const string CMD_SETCONFIGS = "SetConfigs";
        public const string CMD_GETCONFIG = "GetConfig";
        public const string CMD_GETCONFIGS = "GetConfigs";

        public const string CMD_GETCLIENTS = "GetClients";

        public const string CMD_GETLISTMEDIA = "GetListMedia";

        public const string CMD_DELETEALLPLAYLISTIMAGE = "DeleteAllPlaylistImage";
        public const string CMD_DELETEALLPLAYLISTAUDIO = "DeleteAllPlaylistAudio";
        public const string CMD_DELETEINTERFACES = "DeleteInterfaces";
        public const string CMD_DELETEALLPRACTICE = "DeleteAllPractice";

        public const string CMD_DELETEALLMEDIA = "DeleteMediaAlias";



        public const string CMD_REBOOT = "Reboot";
        public const string CMD_STOPALLPROCESS = "StopAllProcess";
        public const string CMD_RESTARTDHCP = "RestartDHCP";
        public const string CMD_SHOWINFO = "showInfo";



        public const string CMD_FILEIMAGESELECTED = "fileImageSelected";

        public const string FILETYPE_MEDIA = "media";
        public const string FILETYPE_LAYOUT = "layout";
        public const string FILETYPE_INTERFACE = "interface";
        public const string FILETYPE_SETTING = "";





        List<JObject> pollMessages = new List<JObject>();

        public struct messageSender<T>
        {
            public string cmd;
            public T value;
            public string name;
            public string alias { get { return App.alias; } }
            public string sport { get { return App.sport.name; } }

        }

        public struct messageReceiver<T>
        {
            public string sender;
            public string status;
            public T value;
            public string name;
        }

        public struct messageReceiverSystem<T>
        {
            public string cmd;
            public T value;
        }

        public struct messageError
        {
            public string status;
            public string sender;
            public int error_code;
            public string error_message;
        }

        public struct FileProp
        {
            public string filename;
            public string filepath;
            public bool exist;
            public bool forceUpload;
            public string type;
        };

        public struct section
        {
            public string name;
            public section_value value;
        };


        public struct section_value
        {
            public string attrib;
            public string value;
        };

        public struct playlist
        {
            public string name;
            public string animation;
            public int type;
            public List<FileProp> files;
        };

        public struct playlistvalue
        {
            public string hashname;
            public string title;
        }

        public struct playlistsetvalue
        {
            public string hashname;
            public string title;
            public string onfinish;
            public int max_counter_time;
            public List<playlistfile> items;
        }


        public struct playlistfile
        {
            public string filename;
            public int duration;
            public int type;
        }



        public struct practicevalue
        {
            public string hashname;
            public string title;
        }


        public struct practicesetvalue
        {
            public string hashname;
            public string title;
            public List<practicefile> items;
            public int totalduration;
            public int type;
        }

        public struct practicefile
        {
            public string filename;
            public int work;
            public int rest;
            public int soundrest;
            public int soundwork;
            public int type;
            public int round;
        }

        public struct customtextvalue
        {
            public string hashname;
            public string title;
        }

        public struct current_setting
        {
            public string version;
            public string deviceName;
            public string role;
            //TODO per versione ledbox 0.5
            //public string sport;
            public string current_layout;
            public List<plugin> plugins;


        }


        public struct plugin
        {
            public string name;
            public float version;
            public List<JObject> parameters;
        }

        public struct horn
        {
            public int times;
            public float sleep;

        };



        public struct config
        {
            public string section;
            public string field;
            public string value;
            public string device;

        }


        public struct client
        {
            public string id;
            public string socket;
            public string alias;
            public string sport;
            public string type;
            public config[] configs;


        }


        public APILedbox()
        {
        }


        /// <summary>
        /// Crea un messaggio LEDbox per inizializzare il ledbox
        /// </summary>
        /// <returns>The init message.</returns>
        /// <param name="alias">Alias.</param>
        public string createInitMessage(string alias)
        {
            messageSender<current_setting> m = new messageSender<current_setting>();
            m.cmd = CMD_INIT;
            m.name = alias;
            m.value = new current_setting();
            m.value.version ="NET MAUI";
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Disconnette il client dal LEDbox
        /// </summary>
        /// <returns></returns>
        public string createDisconnectMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DISCONNECT;
            m.name = "";
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per impostare una sezione nel layout corrente
        /// </summary>
        /// <returns>The section message.</returns>
        /// <param name="name">Name.</param>
        /// <param name="attrib">Attrib.</param>
        /// <param name="value">Value.</param>
        public string createSectionMessage(string name, string attrib, string value)
        {
            messageSender<section_value> m = new messageSender<section_value>();
            m.cmd = CMD_SETSECTION;
            m.name = name;

            section_value s = new section_value();

            s.attrib = attrib;
            s.value = value;

            m.value = s;
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per impostare una sezione nel layout corrente
        /// </summary>
        /// <returns>The section message.</returns>
        /// <param name="name">Name.</param>
        /// <param name="attrib">Attrib.</param>
        /// <param name="value">Value.</param>
        public string createSectionsMessage(section[] sections)
        {
            messageSender<section[]> m = new messageSender<section[]>();
            m.cmd = CMD_SETSECTIONS;
            m.value = sections;
            return JsonConvert.SerializeObject(m);
        }


        /// <summary>
        /// Crea un messaggio LEDbox per l'invio di file
        /// </summary>
        /// <returns>The file upload message.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="filepath">Filepath.</param>
        public string createFileUploadMessage(string filename, string filepath, string alias, string type, bool forceUpload = false)
        {


            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_UPLOAD;
            m.name = "";

            FileProp f = new FileProp();

            f.filename = filename;
            f.filepath = filepath;
            //f.alias = alias;

            //TODO per versione ledbox 0.5
            //f.sport = App.sport.name;

            f.exist = false;
            f.type = type;
            f.forceUpload = forceUpload;


            m.value = f;
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per l'invio di file
        /// </summary>
        /// <returns>The file upload message.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="filepath">Filepath.</param>
        public string createChangeWaitingMessage(string filepath)
        {


            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_CHANGEWAITING;
            m.name = "";

            FileProp f = new FileProp();

            f.filepath = filepath;
            f.forceUpload = true;
            m.value = f;
            return JsonConvert.SerializeObject(m);
        }




        /// <summary>
        /// Crea un messaggio LEDbox per la selezione del layout
        /// </summary>
        /// <returns>The layout message.</returns>
        /// <param name="name">Name.</param>
        public string createLayoutMessage(string name)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_SETLAYOUT;
            m.name = name;
            m.value = name;
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per la selezione del layout
        /// </summary>
        /// <returns>The layout message.</returns>
        /// <param name="name">Name.</param>
        public string createReloadLayoutMessage(string name)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_RELOADLAYOUT;
            m.name = name;
            m.value = name;
            return JsonConvert.SerializeObject(m);
        }

        public string createClearMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_CLEAR;
            m.name = "";
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createRebootMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_REBOOT;
            m.name = "";
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createRestartDHCPMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_RESTARTDHCP;
            m.name = "";
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }


        public string createUplodedMessage(string path_file_uploaded)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_UPLOADED;
            m.name = "";
            m.value = path_file_uploaded;
            return JsonConvert.SerializeObject(m);
        }

        /* PLAYLIST */

        /*public string createPlaylistMessage(Playlist playlist, int type)
        {
            if (type == Playlist.TYPE_IMAGE || type == Playlist.TYPE_VIDEO)
                return createPlaylistImageMessage(playlist);
            else
                return createPlaylistAudioMessage(playlist);
        }

        public string createStartPlaylistMessage(string playlistname, string playlisttitle, int type)
        {
            if (type == Playlist.TYPE_IMAGE || type == Playlist.TYPE_VIDEO)
                return createStartPlaylistImageMessage(playlistname, playlisttitle);
            else
                return createStartPlaylistAudioMessage(playlistname, playlisttitle);
        }

        public string createPausePlaylistMessage(string playlistname, int type)
        {
            if (type == Playlist.TYPE_IMAGE || type == Playlist.TYPE_VIDEO)
                return createPausePlaylistImageMessage(playlistname);
            else
                return createPausePlaylistAudioMessage(playlistname);
        }

        public string createStopPlaylistMessage(string playlistname, int type)
        {
            if (type == Playlist.TYPE_IMAGE || type == Playlist.TYPE_VIDEO)
                return createStopPlaylistImageMessage(playlistname);
            else
                return createStopPlaylistAudioMessage(playlistname);
        }*/

        /*PLAYLIST IMAGE*/

        /*public string createPlaylistImageMessage(Playlist playlist)
        {
            messageSender<playlistsetvalue> m = new messageSender<playlistsetvalue>();
            m.cmd = CMD_SETPLAYLISTIMAGE;
            m.value = new playlistsetvalue()
            {
                hashname = playlist.hashname,
                title = playlist.title,
                onfinish = playlist.onfinish,
                max_counter_time = playlist.max_counter_time,
                items = playlist.items_api
            };
            return JsonConvert.SerializeObject(m);
        }
        */


        public string createStartPlaylistImageMessage(string playlistname, string playlisttitle = "")
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_STARTPLAYLISTIMAGE;
            m.value = new playlistvalue() { hashname = playlistname, title = playlisttitle };
            return JsonConvert.SerializeObject(m);
        }

        public string createPausePlaylistImageMessage(string playlistname)
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_PAUSEPLAYLISTIMAGE;

            m.value = new playlistvalue() { hashname = playlistname };
            return JsonConvert.SerializeObject(m);

        }

        public string createStopPlaylistImageMessage(string playlistname)
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_STOPPLAYLISTIMAGE;
            m.value = new playlistvalue() { hashname = playlistname };
            return JsonConvert.SerializeObject(m);
        }

        public string createGetListPlaylistImageMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_GETLISTPLAYLISTIMAGE;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createDeleteAllPlaylistImageMessage(string alias)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DELETEALLPLAYLISTIMAGE;
            m.name = alias;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per l'invio di file
        /// </summary>
        /// <returns>The file upload message.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="filepath">Filepath.</param>
        public string createUploadPlaylistImageMessage(string filename, string filepath, bool forceUpload = false)
        {

            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_UPLOADLISTPLAYLISTIMAGE;
            m.name = "";

            FileProp f = new FileProp();

            f.filename = filename;
            f.filepath = filepath;
            f.exist = false;
            f.forceUpload = forceUpload;

            m.value = f;
            return JsonConvert.SerializeObject(m);
        }

        /*PLAYLIST AUDIO*/

        /*public string createPlaylistAudioMessage(Playlist playlist)
        {
            messageSender<playlistsetvalue> m = new messageSender<playlistsetvalue>();
            m.cmd = CMD_SETPLAYLISTAUDIO;
            m.value = new playlistsetvalue()
            {
                hashname = playlist.hashname,
                title = playlist.title,
                onfinish = playlist.onfinish,
                max_counter_time = playlist.max_counter_time,
                items = playlist.items_api
            };
            return JsonConvert.SerializeObject(m);
        }*/

        public string createStartPlaylistAudioMessage(string playlistname, string playlisttitle = "")
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_STARTPLAYLISTAUDIO;
            m.value = new playlistvalue() { hashname = playlistname, title = playlisttitle };
            return JsonConvert.SerializeObject(m);
        }

        public string createPausePlaylistAudioMessage(string playlistname)
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_PAUSEPLAYLISTAUDIO;

            m.value = new playlistvalue() { hashname = playlistname, title = "" };
            return JsonConvert.SerializeObject(m);
        }

        public string createStopPlaylistAudioMessage(string playlistname)
        {
            messageSender<playlistvalue> m = new messageSender<playlistvalue>();
            m.cmd = CMD_STOPPLAYLISTAUDIO;
            m.value = new playlistvalue() { hashname = playlistname };
            return JsonConvert.SerializeObject(m);
        }

        public string createGetListPlaylistAudioMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_GETLISTPLAYLISTAUDIO;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createDeleteAllPlaylistAudioMessage(string alias)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DELETEALLPLAYLISTAUDIO;
            m.name = alias;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per l'invio di file
        /// </summary>
        /// <returns>The file upload message.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="filepath">Filepath.</param>
        public string createUploadPlaylistAudioMessage(string filename, string filepath, bool forceUpload = false)
        {

            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_UPLOADLISTPLAYLISTAUDIO;
            m.name = "";

            FileProp f = new FileProp();

            f.filename = filename;
            f.filepath = filepath;
            f.exist = false;
            f.forceUpload = forceUpload;

            m.value = f;
            return JsonConvert.SerializeObject(m);
        }

        /* PRACTICE */

        public string createStartPracticeMessage(string practicename, string practicetitle)
        {
            messageSender<practicevalue> m = new messageSender<practicevalue>();
            m.cmd = CMD_STARTPRACTICE;
            m.value = new practicevalue() { hashname = practicename, title = practicetitle };
            return JsonConvert.SerializeObject(m);
        }

        /*public string createPracticeMessage(Practice practice)
        {
            messageSender<practicesetvalue> m = new messageSender<practicesetvalue>();
            m.cmd = CMD_SETPRACTICE;
            m.value = new practicesetvalue()
            {
                hashname = practice.hashname,
                title = practice.title,
                items = practice.items_api,
                totalduration = practice.totalduration,
                type = practice.type
            };

            return JsonConvert.SerializeObject(m);
        }*/

        public string createPausePracticeMessage(string practicename)
        {
            messageSender<practicevalue> m = new messageSender<practicevalue>();
            m.cmd = CMD_PAUSEPRACTICE;
            m.value = new practicevalue() { hashname = practicename };
            return JsonConvert.SerializeObject(m);
        }

        public string createStopPracticeMessage(string practicename)
        {
            messageSender<practicevalue> m = new messageSender<practicevalue>();
            m.cmd = CMD_STOPPRACTICE;
            m.value = new practicevalue() { hashname = practicename };
            return JsonConvert.SerializeObject(m);
        }

        public string createGetListPracticeMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_GETLISTPRACTICE;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createDeleteAllPracticeMessage(string alias)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DELETEALLPRACTICE;
            m.name = alias;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        /// <summary>
        /// Crea un messaggio LEDbox per l'invio di file
        /// </summary>
        /// <returns>The file upload message.</returns>
        /// <param name="filename">Filename.</param>
        /// <param name="filepath">Filepath.</param>
        public string createUploadPracticeMessage(string filename, string filepath, bool forceUpload = false)
        {

            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_UPLOADPRACTICE;
            m.name = "";

            FileProp f = new FileProp();

            f.filename = filename;
            f.filepath = filepath;
            f.exist = false;
            f.forceUpload = forceUpload;

            m.value = f;
            return JsonConvert.SerializeObject(m);
        }




        /* CUSTOM TEXT */

        public string createStartCustomTextMessage(CustomText customText = null)
        {
            messageSender<CustomText> m = new messageSender<CustomText>();
            m.cmd = CMD_STARTCUSTOMTEXT;
            m.value = customText;
            return JsonConvert.SerializeObject(m);
        }

        public string createPauseCustomTextMessage(CustomText customText = null)
        {
            messageSender<CustomText> m = new messageSender<CustomText>();
            m.cmd = CMD_PAUSECUSTOMTEXT;
            m.value = customText;
            return JsonConvert.SerializeObject(m);
        }

        public string createStopCustomTextMessage(string customTitle)
        {
            messageSender<customtextvalue> m = new messageSender<customtextvalue>();
            m.cmd = CMD_STOPCUSTOMTEXT;
            m.value = new customtextvalue() { hashname = customTitle };
            return JsonConvert.SerializeObject(m);
        }

        /* INTERFACES */

        public string createDeleteAllIntefacesMessage()
        {

            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DELETEINTERFACES;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }
        /* HORN */

        public string createHornMessage(int idx)
        {
            int times = 0;
            float sleep = 0.5f;

            switch (idx)
            {
                case 0: //nessun suono
                    times = 0;
                    break;
                case 1: //1 suono breve
                    times = 1;
                    sleep = 0.5f;
                    break;
                case 2: //2 suoni brevi
                    times = 2;
                    sleep = 0.5f;
                    break;
                case 3: //3 suoni brevi
                    times = 3;
                    sleep = 0.5f;
                    break;
                case 4: //1 suono lungo
                    times = 1;
                    sleep = 1f;
                    break;
                case 5: //2 suono lungo
                    times = 2;
                    sleep = 1f;
                    break;
                case 6: //3 suono lungo
                    times = 3;
                    sleep = 1f;
                    break;
            }

            messageSender<horn> m = new messageSender<horn>();
            m.cmd = CMD_HORN;

            m.value = new horn() { times = times, sleep = sleep };


            return JsonConvert.SerializeObject(m);



        }


        public string createDeleteAllMedia(string alias)
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_DELETEALLMEDIA;
            m.name = alias;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }


        public string createSetConfigMessage(config config)
        {
            messageSender<config> m = new messageSender<config>();
            m.cmd = CMD_SETCONFIG;
            m.value = config;
            return JsonConvert.SerializeObject(m);
        }

        public string createSetConfigsMessage(config[] configs)
        {
            messageSender<config[]> m = new messageSender<config[]>();
            m.cmd = CMD_SETCONFIGS;
            m.value = configs;
            return JsonConvert.SerializeObject(m);
        }

        public string createGetConfigMessage(config config)
        {
            messageSender<config> m = new messageSender<config>();
            m.cmd = CMD_GETCONFIG;
            m.value = config;
            return JsonConvert.SerializeObject(m);
        }

        public string createGetConfigsMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_GETCONFIGS;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createGetClientsMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_GETCLIENTS;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createStopAllProcessMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_STOPALLPROCESS;
            m.value = "";
            return JsonConvert.SerializeObject(m);
        }

        public string createFileImageSelected(FileProp file, string name)
        {
            messageSender<FileProp> m = new messageSender<FileProp>();
            m.cmd = CMD_FILEIMAGESELECTED;
            m.name = name;
            m.value = file;
            return JsonConvert.SerializeObject(m);
        }

        public string createShowInfoMessage()
        {
            messageSender<string> m = new messageSender<string>();
            m.cmd = CMD_SHOWINFO;
            m.name = "";
            return JsonConvert.SerializeObject(m);
        }


        public messageReceiver<T> parseMessage<T>(string message)
        {
            messageReceiver<T> m = new messageReceiver<T>();

            m = JsonConvert.DeserializeObject<messageReceiver<T>>(message);

            return m;

        }

        public messageReceiverSystem<T> parseMessageSystem<T>(string message)
        {
            messageReceiverSystem<T> m = new messageReceiverSystem<T>();

            m = JsonConvert.DeserializeObject<messageReceiverSystem<T>>(message);

            return m;

        }

        public messageError parseErrorMessage(string message)
        {
            messageError m = new messageError();

            m = JsonConvert.DeserializeObject<messageError>(message);

            return m;

        }

    }
}
