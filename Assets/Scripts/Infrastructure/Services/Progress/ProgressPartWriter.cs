using System;
using Data;

namespace Infrastructure.Services
{
    [Serializable]
    public abstract class ProgressPartWriter : IProgressWriter
    {
        public virtual void ReadProgress(GameProgress progress) {}
        public virtual void WriteProgress(GameProgress progress) {}
    }
}