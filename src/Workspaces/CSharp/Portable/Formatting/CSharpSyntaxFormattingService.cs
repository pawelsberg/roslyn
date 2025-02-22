﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Composition;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Microsoft.CodeAnalysis.CSharp.Formatting
{
    [ExportLanguageService(typeof(ISyntaxFormattingService), LanguageNames.CSharp), Shared]
    internal class CSharpSyntaxFormattingService : CSharpSyntaxFormatting, ISyntaxFormattingService
    {
        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public CSharpSyntaxFormattingService()
        {
        }
    }
}
