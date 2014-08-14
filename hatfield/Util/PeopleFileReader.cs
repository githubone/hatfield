using hatfield.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hatfield.Util
{
    public static class PeopleFileReader
    {
        public static async Task<List<PeopleModel>> GetPeopleData(string filePath)
        {
            string lineContent;
            string[] lineContents;
            List<PeopleModel> peopleData = new List<PeopleModel>();

            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    lineContent = await reader.ReadLineAsync();
                    lineContents = lineContent.Split(',');
                    peopleData.Add(new PeopleModel()
                    {
                        Name = lineContents[0],
                        DateOfBirth = lineContents[1],
                        BirthPlace = lineContents[2],
                        Height = lineContents[3],
                        Weight = lineContents[4]
                    });
                }
            }

            return peopleData;

        }
    }
}