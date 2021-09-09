using ApplicationCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MartianRobotDataService : IMartianRobotDataService
    {

        public async Task<MartianRobotInputDataDTO> GetAllAsync()
        {
            MartianRobotInputDataDTO result = new MartianRobotInputDataDTO();

            var fileData = await File.ReadAllLinesAsync(Constants.FILE_NAME);

            var mapData = fileData[0].Split(Constants.SPLIT_STRING);

            result.PlanetWidth = int.Parse(mapData[0]);
            result.PlanetHeight = int.Parse(mapData[1]);
            

            result.RobotsData = GetRobotsData(fileData);

            return result;
        }

        private static List<RobotDataDTO> GetRobotsData(string[] fileData)
        {
            List<RobotDataDTO> result = new List<RobotDataDTO>();
            RobotDataDTO robot;
            for (int i = 1; i < fileData.Length; i += 2)
            {
                robot = new RobotDataDTO();
                robot.CurrentPosition = fileData[i];
                robot.Orders = fileData[i + 1];
                result.Add(robot);
            }
            return result;
        }
    }
}
