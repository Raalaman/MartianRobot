using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApplicationCore
{
    public class CoordinateModel
    {
        [Range(0, 50)]
        public int x { get; set; }

        [Range(0, 50)]
        public int y { get; set; }

        public Orientation Orientation { get; set; }

        /// <summary>
        /// Mueve el robot, en caso de caerse del mapa devuelve false
        /// </summary>
        /// <param name="model">el mapa</param>
        /// <returns>True si se ha movido con éxito, false en caso contrario</returns>
        public TravelResult MoveForWard(MartianRobotGridModel model)
        {
            TravelResult result = TravelResult.Lost;

            switch (Orientation)
            {
                case Orientation.E:
                    result = ValidatePosition(model, x + 1, Dimension.Length);
                    if (result == TravelResult.OK)
                    {
                        x++;
                    }

                    break;
                case Orientation.N:
                    result = ValidatePosition(model, y + 1, Dimension.Height);
                    if (result == TravelResult.OK)
                    {
                        y++;
                    }

                    break;
                case Orientation.S:
                    result = ValidatePosition(model, y - 1, Dimension.Height);
                    if (result == TravelResult.OK)
                    {
                        y--;
                    }

                    break;
                case Orientation.W:
                    result = ValidatePosition(model, x - 1, Dimension.Length);
                    if (result == TravelResult.OK)
                    {
                        x--;
                    }
                    break;
            }

            return result;
        }

        public override string ToString()
        {
            return $"{x} {y} {Orientation}";
        }

        private TravelResult ValidatePosition(MartianRobotGridModel model, int position, Dimension dimension)
        {
            switch (dimension)
            {
                case Dimension.Height:
                    if (model.CoordinatesLostRobots.Any(finishedRobot => finishedRobot.x == x && finishedRobot.y == y && finishedRobot.Orientation==Orientation))
                    {
                        return TravelResult.Ignore;
                    }
                    if (position <= model.Height || position < 0)
                    {
                        return TravelResult.OK;
                    }
                    break;
                case Dimension.Length:
                    if (model.CoordinatesLostRobots.Any(finishedRobot => finishedRobot.x == x && finishedRobot.y == y && finishedRobot.Orientation == Orientation))
                    {
                        return TravelResult.Ignore;
                    }
                    if (position <= model.Length || position < 0)
                    {
                        return TravelResult.OK;
                    }
                    break;
            }
            return TravelResult.Lost; 
        }
    }
}