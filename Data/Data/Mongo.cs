using Data.Models.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class Mongo
    {

        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<Login> collectionLogin;

        public Mongo()
        {
            try
            {
                dbClient = new MongoClient("mongodb+srv://Airdrop:AirdropPassword@cluster0.bxc6qlh.mongodb.net/test");
                database = dbClient.GetDatabase("Airdrop");
                collectionLogin = database.GetCollection<Login>("Basic");
            }
            catch (Exception ex)
            {

                dbClient = null;
                database = null;
                collectionLogin = null;
            }

        }
        public async Task<bool> Insert(Login login)
        {
            try
            {
                await collectionLogin.InsertOneAsync(login);
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
       
        public async Task<Login> Find(Login login)
        {
            try
            {
                var result = await collectionLogin.FindAsync<Login>(d => d.User == login.User && d.Password == login.Password  && d.License == login.License);
                List<Login> resultlist = await result.ToListAsync();
                if (resultlist.Count > 0)
                {
                    return (Login)resultlist[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Login> Update(Login login)
        {
            try
            {
                Login loginTemp = await Find(login);
                if (loginTemp == null)
                {
                    return null;
                }
                login.Id = loginTemp.Id;
                loginTemp.ValidTo = DateTime.Now;
                var result = collectionLogin.ReplaceOne(p => p.Id == loginTemp.Id, login);
                return login;
               
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
