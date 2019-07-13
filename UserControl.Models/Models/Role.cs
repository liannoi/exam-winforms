﻿// Copyright 2019 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace UserControl.Models.Models
{
    /// <summary>
    /// Role model.
    /// </summary>
    [Serializable]
    public class Role
    {
        /// <summary>
        /// Unique identifier for current role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name for current role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag, is the current role checked.
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
