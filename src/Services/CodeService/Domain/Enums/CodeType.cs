using Ardalis.SmartEnum;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RB.Storage.CodeService.Domain.UnitTests")]
namespace RB.Storage.CodeService.Domain.Enums;

public sealed class CodeType(string name, int value) : SmartEnum<CodeType>(name, value)
{
    public static int MinValue => List.Min(ct => ct.Value);
    public static int MaxValue => List.Max(ct => ct.Value);

    public static readonly CodeType Default = new(nameof(Default), 0);
    public static readonly CodeType Verification = new(nameof(Verification), 1);
}
