using GoogleSearcher;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcDAL
{
    public class AcMongoDAL
    {
        #region Members
        
        private static object syncRoot = new Object();

        private static MongoClient client = null; 
        
        #endregion

        #region Properties

        public static string ConnectionString
        {
            get
            {
                string connectionString = null;

                try
                {
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[MongoConsts.MONGO_DB_CONNETCTION_STRING_NAME].ConnectionString;
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Error in AcMongoDAL.ConnectionString e:{0}", e.Message));
                    throw;
                }

                return connectionString;
            }
        }

        public static MongoClient MongoClient
        {
            get
            {
                if (client == null)
                {
                    lock (syncRoot)
                    {
                        if (client == null)
                        {
                            client = new MongoClient(AcMongoDAL.ConnectionString);
                            AcMongoDAL.AddDefaultIndex();
                        }
                    }
                }
                return client;
            }
        }

        public static IMongoDatabase GoogleMongoDB
        {
            get
            {
                return AcMongoDAL.MongoClient.GetDatabase(MongoConsts.GOOGLE_INFO_DB_NAME);
            }
        } 

        #endregion

        #region Ctor

        public AcMongoDAL()
        {

        }
 
        #endregion
        
        #region Methods

        public static async void AddDefaultIndex()
        {
            try
            {
                var keys = Builders<BsonDocument>.IndexKeys.Ascending(MongoConsts.TEXT_TO_SEARCH_MONGO_FIELD);
                var indexOptions = new CreateIndexOptions();
                indexOptions.Unique = true;
                var collection = AcMongoDAL.GoogleMongoDB.GetCollection<BsonDocument>(MongoConsts.GOOGLE_BEST_RESULT_COLLECTION_NAME);
                await collection.Indexes.CreateOneAsync(keys, indexOptions);
            }
            catch (TimeoutException timeotEx)
            {
                Console.WriteLine("Please Make Sure MongoDB Is Running");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Adding Index To MongoDB", e.Message);
            }
        }

        public bool saveGoogleDocuments(IEnumerable<GoogleData> googleDocuments)
        {
            bool success = false;

            foreach (var item in googleDocuments)
            {
                success = this.saveGoogleDocument(item);
            }

            return success;
        }

        public bool saveGoogleDocument(GoogleData googleDataToSave)
        {
            bool success = false;

            try
            {
                var collection = AcMongoDAL.GoogleMongoDB.GetCollection<BsonDocument>(MongoConsts.GOOGLE_BEST_RESULT_COLLECTION_NAME);
                var documentToInsert = googleDataToSave.ToBsonDocument<GoogleData>();
                collection.InsertOne(documentToInsert);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error in AcMongoDAL.saveGoogleDocument e:{0}", e.Message));
            }

            return success;
        }
 
        #endregion

    }
}
