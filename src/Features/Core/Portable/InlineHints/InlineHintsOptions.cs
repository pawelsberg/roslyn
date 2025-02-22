﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;
using Microsoft.CodeAnalysis.LanguageServices;

namespace Microsoft.CodeAnalysis.InlineHints
{
    [DataContract]
    internal readonly record struct InlineHintsOptions(
        [property: DataMember(Order = 0)] InlineParameterHintsOptions ParameterOptions,
        [property: DataMember(Order = 1)] InlineTypeHintsOptions TypeOptions,
        [property: DataMember(Order = 2)] SymbolDescriptionOptions DisplayOptions);
}
