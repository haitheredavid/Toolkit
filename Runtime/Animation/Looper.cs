using UnityEngine;

namespace ToolKit {
    public struct Looper {

        public Looper( float length, bool useRewind )
            {
                this.length = length;
                this.useRewind = useRewind;
                _rewind = false;
                CurrentTime = 0f;
            }

        public readonly float length;
        public readonly bool useRewind;
        private bool _rewind;
        public float CurrentTime { get; private set; }

        public float Check( )
            {
                if ( !_rewind )
                    CurrentTime += Time.deltaTime; // increment forward 
                else
                    CurrentTime -= Time.deltaTime; // increment back

                // reset timer if over threshold
                if ( CurrentTime >= length ) {
                    _rewind = true;
                } else if ( CurrentTime < 0 ) {
                    CurrentTime = 0f;
                    _rewind = false;
                }
                return CurrentTime;
            }

    }
}