//MIT License

//Copyright (c) 2022-2022 Peter Kirmeier

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using System.Reflection;
using LiveSplit.HitCounterManagerConnector;
using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(HitCounterManagerConnectorComponentFactory))]

namespace LiveSplit.HitCounterManagerConnector
{
    public class HitCounterManagerConnectorComponentFactory : IComponentFactory
    {
        public string ComponentName => "HitCounterManager Connector";

        public string Description => "Connects with the HitCounterManager to control the splits via LiveSplit";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => "https://raw.githubusercontent.com/topeterk/LiveSplit.HitCounterManagerConnector/livesplitupdate/LiveSplitUpdates.xml";

        public string UpdateURL => "https://raw.githubusercontent.com/topeterk/LiveSplit.HitCounterManagerConnector/livesplitupdate/";

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public IComponent Create(LiveSplitState state) => new HitCounterManagerConnectorComponent(state);
    }
}
