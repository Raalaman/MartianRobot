using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class OutputGeneratorService : IAsyncOutputGenerator<MartianRobotInputDataDTO, OutputGeneratorDTO>
    {


        public async Task<List<OutputGeneratorDTO>> GenerateOutput(MartianRobotInputDataDTO inputData)
        {
            List<OutputGeneratorDTO> result = new List<OutputGeneratorDTO>();

            MartianRobotGridModel model = new MartianRobotGridModel();
            model.Height = inputData.PlanetHeight;
            model.Length = inputData.PlanetWidth;
            if (!GenericValidator.Validate(model))
                return result;

            TravelRobotModel robotTravel;
            OutputGeneratorDTO output;
            foreach (var robotData in inputData.RobotsData)
            {
                robotTravel = new TravelRobotModel();
                output = new OutputGeneratorDTO();
                robotTravel.InitialCoordinate = GetInitialCoordinateRobot(robotData.CurrentPosition);
                robotTravel.Instructions = GetInstructionsRobot(robotData.Orders);

                if (GenericValidator.Validate(robotTravel))
                {
                    robotTravel.CurrentCoordinate = robotTravel.InitialCoordinate;
                    output.IsLost = false;
                    foreach (var instruction in robotTravel.Instructions)
                    {
                        if (Travel(robotTravel.CurrentCoordinate, instruction, model) == TravelResult.Lost)
                        {
                            model.CoordinatesLostRobots.Add(robotTravel.CurrentCoordinate);
                            output.Coordinate = robotTravel.CurrentCoordinate;
                            output.IsLost = true;
                            break;
                        }
                    }
                    output.Coordinate = robotTravel.CurrentCoordinate;
                    result.Add(output);
                }
            }
            return result;
        }

        private static TravelResult Travel(CoordinateModel currentCoordinate, Instruction instruction, MartianRobotGridModel model)
        {
            TravelResult result = TravelResult.Lost;
            switch (instruction)
            {
                case Instruction.L:
                    currentCoordinate.Orientation = OrientationHelper.TurnLeft(currentCoordinate.Orientation);
                    result = TravelResult.OK;
                    break;

                case Instruction.R:
                    currentCoordinate.Orientation = OrientationHelper.TurnRight(currentCoordinate.Orientation);
                    result = TravelResult.OK;
                    break;

                case Instruction.F:
                    result = currentCoordinate.MoveForWard(model);
                    break;
            }
            return result;
        }





        private static List<Instruction> GetInstructionsRobot(string orders)
        {
            return orders.ToCharArray().Select(x => (Instruction)Enum.Parse(typeof(Instruction), x.ToString())).ToList();
        }

        private static CoordinateModel GetInitialCoordinateRobot(string currentPosition)
        {
            var splittedCurrentPosition = currentPosition.Split(Constants.SPLIT_STRING);
            return new CoordinateModel
            {
                x = int.Parse(splittedCurrentPosition[0]),
                y = int.Parse(splittedCurrentPosition[1]),
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), splittedCurrentPosition[2])
            };
        }
    }
}
