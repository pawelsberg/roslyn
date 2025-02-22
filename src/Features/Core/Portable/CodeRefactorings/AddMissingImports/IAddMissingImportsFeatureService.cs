﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.AddImport;
using Microsoft.CodeAnalysis.CodeGeneration;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.AddMissingImports
{
    [DataContract]
    internal readonly record struct AddMissingImportsOptions(
        [property: DataMember(Order = 0)] bool HideAdvancedMembers,
        [property: DataMember(Order = 1)] AddImportPlacementOptions Placement);

    internal interface IAddMissingImportsFeatureService : ILanguageService
    {
        /// <summary>
        /// Attempts to add missing imports to the document within the textspan provided. The imports added will
        /// not add assembly references to the project. In case of failure, null is returned. Failure can happen
        /// if there are ambiguous imports, no known resolutions to import, or if no imports that would be provided
        /// would be added without adding a reference for the project. 
        /// </summary>
        Task<Document> AddMissingImportsAsync(Document document, TextSpan textSpan, AddMissingImportsOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Analyzes the document inside the texstpan to determine if imports can be added.
        /// </summary>
        Task<AddMissingImportsAnalysisResult> AnalyzeAsync(Document document, TextSpan textSpan, AddMissingImportsOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Performs the same action as <see cref="AddMissingImportsAsync(Document, TextSpan, AddMissingImportsOptions, CancellationToken)"/> but
        /// with a predetermined analysis of the input instead of recalculating it
        /// </summary>
        Task<Document> AddMissingImportsAsync(Document document, AddMissingImportsAnalysisResult analysisResult, CancellationToken cancellationToken);
    }
}
