﻿#region license
// /*
//     This file is part of Vocaluxe.
// 
//     Vocaluxe is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     Vocaluxe is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with Vocaluxe. If not, see <http://www.gnu.org/licenses/>.
//  */
#endregion

using System.Collections.Generic;
using VocaluxeLib.Menu;

namespace Vocaluxe.Lib.Video
{
    abstract class CVideoDecoder : IVideoDecoder
    {
        protected List<SVideoStreams> _Streams = new List<SVideoStreams>();
        protected bool _Initialized = false;

        public virtual bool Init()
        {
            _Streams = new List<SVideoStreams>();
            _Initialized = true;

            return true;
        }

        public abstract void CloseAll();

        public virtual int GetNumStreams()
        {
            return _Streams.Count;
        }

        public virtual int Load(string videoFileName)
        {
            return 0;
        }

        public virtual bool Close(int streamID)
        {
            return true;
        }

        public virtual float GetLength(int streamID)
        {
            return 0f;
        }

        public virtual bool GetFrame(int streamID, ref STexture frame, float time, ref float videoTime)
        {
            return true;
        }

        public virtual bool Skip(int streamID, float start, float gap)
        {
            return true;
        }

        public virtual void SetLoop(int streamID, bool loop) {}

        public virtual void Pause(int streamID) {}

        public virtual void Resume(int streamID) {}

        public virtual bool Finished(int streamID)
        {
            return false;
        }

        public virtual void Update() {}

        protected bool _AlreadyAdded(int streamID)
        {
            foreach (SVideoStreams st in _Streams)
            {
                if (st.Handle == streamID)
                    return true;
            }
            return false;
        }

        protected int _GetStreamIndex(int streamID)
        {
            for (int i = 0; i < _Streams.Count; i++)
            {
                if (_Streams[i].Handle == streamID)
                    return i;
            }
            return -1;
        }
    }
}