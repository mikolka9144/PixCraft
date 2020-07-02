using PixBlocks.Server.DataModels.DataModels;
using PixBlocks.Server.DataModels.DataModels.UserProfileInfo;
using PixBlocks.ServerFasade.ServerAPI;
using PixBlocks.ServerFasade.UserManagment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Engine.GUI
{
    public class WorldManager
    {
        private readonly string MetadataGuid = "74F771CE-2E78-4D5E-AEE9-7674706D02DB"; 
        public WorldManager()
        {
            Serializer = new XmlSerializer(typeof(WorldEntry));
            Api = new ServerApi();       
            QuestionsResults = Api.GetAllQuestionsCodes(CurrentUserInfo.CurrentUser,CurrentUserInfo.AuthorizeData);
            metadata = QuestionsResults.Find(s => s.QuesionGuid == MetadataGuid);
            if (metadata is null)
            {
                var meta = new EditedQuestionCode();
                meta.QuesionGuid = MetadataGuid;
                meta.QeditedQuesionCodeBase64 = ConvertBase64(new List<WorldEntry>());
                meta.UserId = (int)CurrentUserInfo.CurrentUser.Id;
                meta.CreationTime = DateTime.Now;
                Api.AddOrUpdateEditedQuestionCode(meta,CurrentUserInfo.CurrentUser, CurrentUserInfo.AuthorizeData);
                metadata = meta;
            }
            ListOfWorlds = ConvertBase64(metadata.QeditedQuesionCodeBase64);
        }

        private string ConvertBase64(List<WorldEntry> lists)
        {
            var bin = new MemoryStream();
            Serializer.Serialize(bin,lists);
            return Convert.ToBase64String(bin.ToArray());
        }
        private List<WorldEntry> ConvertBase64(string base64)
        {
            var bin = new MemoryStream(Convert.FromBase64String(base64));
            return (List<WorldEntry>)Serializer.Deserialize(bin);
            
        }

        public XmlSerializer Serializer { get; }
        public ServerApi Api { get; }
        public List<EditedQuestionCode> QuestionsResults { get; private set; }
        public List<WorldEntry> ListOfWorlds { get; }

        private EditedQuestionCode metadata;

        internal void SaveWorld(string name, string data)
        {
            var QuestionResult = new EditedQuestionCode();
            QuestionResult.QeditedQuesionCodeBase64 = data;
            QuestionResult.QuesionGuid = Guid.NewGuid().ToString();
            QuestionResult.UserId = (int)CurrentUserInfo.CurrentUser.Id;
            QuestionResult.CreationTime = DateTime.Now;

            ListOfWorlds.Add(new WorldEntry(name, QuestionResult.QuesionGuid));
            QuestionsResults.Add(QuestionResult);
            SyncMetadata();
            Api.AddOrUpdateEditedQuestionCode(QuestionResult, CurrentUserInfo.CurrentUser, CurrentUserInfo.AuthorizeData);
        }

        private void SyncMetadata()
        {
            metadata.QeditedQuesionCodeBase64 = ConvertBase64(ListOfWorlds);

            Api.AddOrUpdateEditedQuestionCode(metadata, CurrentUserInfo.CurrentUser, CurrentUserInfo.AuthorizeData);
        }

        internal string LoadWorld(string name)
        {
            var guid = ListOfWorlds.Find(s => s.Name == name);
            if (guid is null) return "";
            var world = QuestionsResults.Find(s => s.QuesionGuid == guid.Guid);
            if (world is null) return "";
            return world.QeditedQuesionCodeBase64;

        }
    }
}