using Officely.StorageService.Domain.Entities;
using RB.SharedKernel.MediatR.Command;
namespace Officely.StorageService.Application.Commands.InitializeUserDirectory;

public record Result(StorageItem StorageItem) : ICommandResult;
