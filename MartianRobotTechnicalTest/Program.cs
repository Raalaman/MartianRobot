using ApplicationCore;
using AutoMapper;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MartianRobotTechnicalTest
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            var host = AppStartup();
            try
            {
                Log.Information("Creating instance MartianRobotDataService");
                var service = ActivatorUtilities.CreateInstance<MartianRobotDataService>(host.Services);

                Log.Information("Creating instance OutputGeneratorService");
                var outputService = ActivatorUtilities.CreateInstance<OutputGeneratorService>(host.Services);

                Log.Information("Getting InputData");
                MartianRobotInputDataDTO robotData = await service.GetAllAsync();


                Log.Information("Generating Output");
                List<OutputGeneratorDTO> outputData = await outputService.GenerateOutput(robotData);

                PrintOutPutData(outputData);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void PrintOutPutData(List<OutputGeneratorDTO> outputData)
        {
            foreach (var output in outputData)
            {
                Console.WriteLine(output.ToString());
            }
        }

        private static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>return <see cref="IHost"/> with all the services loaded</returns>
        private static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);
            var configuration = builder.Build();

            //Config Serilog to sink data into Console
            var loggerConf = new LoggerConfiguration()
             .ReadFrom.Configuration(configuration)
             .Enrich.FromLogContext()
             .WriteTo.Console();

            if (Debugger.IsAttached)
                loggerConf.MinimumLevel.Debug();
            else
                loggerConf.MinimumLevel.Error();


            Log.Logger = loggerConf.CreateLogger();


            // Add services to current host
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) =>
                        {
                            services.AddSingleton(typeof(IMartianRobotDataService), typeof(MartianRobotDataService));
                            services.AddSingleton(typeof(IAsyncOutputGenerator<MartianRobotInputDataDTO, OutputGeneratorDTO>), typeof(OutputGeneratorService));
                        })
                        .UseSerilog()
                        .Build();



            return host;
        }
    }
}
