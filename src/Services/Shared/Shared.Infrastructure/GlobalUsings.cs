global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Principal;
global using System.Text;
global using System.Text.Encodings.Web;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.Reflection;
global using System.Net.Sockets;
global using System.Text.Json;
global using Polly;
global using Shared.Domain.Abstractions;
global using Microsoft.EntityFrameworkCore;
global using Shared.Domain.Entities.Bus;
global using Shared.Domain.SeedWork;
global using MediatR;
global using RabbitMQ.Client;
global using RabbitMQ.Client.Events;
global using RabbitMQ.Client.Exceptions;