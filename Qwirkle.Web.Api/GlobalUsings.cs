﻿global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Qwirkle.AI;
global using Qwirkle.Authentication.Adapters;
global using Qwirkle.Domain.Entities;
global using Qwirkle.Domain.Enums;
global using Qwirkle.Domain.Ports;
global using Qwirkle.Domain.Services;
global using Qwirkle.Domain.ValueObjects;
global using Qwirkle.Infra.Repository;
global using Qwirkle.Infra.Repository.Adapters;
global using Qwirkle.Infra.Repository.Dao;
global using Qwirkle.SignalR;
global using Qwirkle.SignalR.Adapters;
global using Qwirkle.Web.Api.ViewModels;
global using Serilog;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using System.Threading.Tasks;
