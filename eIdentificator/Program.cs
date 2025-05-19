using eIdentificator.Application.Services;
using eIdentificator.Domain.Interfaces;
using eIdentificator.Infrastructure.Helpers;
using eIdentificator.Infrastructure.Repositories;
using eIdentificator.Application.Helpers;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace eIdentificator
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            var host = CreateHostBuilder().Build();

            System.Windows.Forms.Application
                .EnableVisualStyles();
            System.Windows.Forms.Application
                .SetCompatibleTextRenderingDefault(false);

            var databaseHelper = host.Services
                .GetRequiredService<IDatabaseHelper>();
            databaseHelper.InitializeDatabase();

            var fileHelper = host.Services
                .GetRequiredService<IFileHelper>();

            var passwordHelper = host.Services
                .GetRequiredService<IPasswordHelper>();
            var formHelper = host.Services
                .GetRequiredService<IFormHelper>();
            var dateHelper = host.Services
                .GetRequiredService<IDateHelper>();
            var listHelper = host.Services
                .GetRequiredService<IListHelper>();

            var studentsService = host.Services
                .GetRequiredService<StudentsService>();

            using (FormLogin formLogin = new FormLogin(
                formHelper, 
                passwordHelper
                )
            )
            {
                formLogin.ShowDialog();
                if (formLogin.IsAuthenticated)
                {
                    System.Windows.Forms.Application.Run(
                        new FormIdentification(
                            databaseHelper,
                            fileHelper,
                            formHelper,
                            dateHelper,
                            listHelper,
                            studentsService
                        )
                    );
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern bool SetProcessDPIAware();

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddAutoMapper(typeof(Program));
                    services
                        .AddSingleton<FormIdentification>();
                    services
                        .AddSingleton<IDatabaseHelper, DatabaseHelper>();
                    services
                        .AddScoped<IFileHelper, FileHelper>();
                    services
                        .AddScoped<IPasswordHelper, PasswordHelper>();
                    services
                        .AddScoped<IFormHelper, FormHelper>();
                    services
                        .AddScoped<IDateHelper, DateHelper>();
                    services
                        .AddScoped<IListHelper, ListHelper>();
                    services
                        .AddScoped<IStudentsRepository, StudentsRepository>();
                    services
                        .AddSingleton<StudentsService>();
                });
        }
    }
}