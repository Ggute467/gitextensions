        private List<Patch> _patches = new List<Patch>();

        public List<Patch> Patches
        {
            get { return _patches; }
            set { _patches = value; }
        }

            string header;

            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, staged, out header);

            string header;

            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, staged, out header);
            else
                return GetPatchBytes(header, body, fileContentEncoding);
            _patches = patchProcessor.CreatePatchesFromString(text).ToList();
            foreach (Patch patchApply in _patches)
            SubChunkToPatchFnc subChunkToPatch = (SubChunk subChunk, ref int addedCount, ref int removedCount, ref bool wereSelectedLines) =>
                {
                    return subChunk.ToResetUnstagedLinesPatch(ref addedCount, ref removedCount, ref wereSelectedLines);
                };
            return ToPatch(subChunkToPatch);
            SubChunkToPatchFnc subChunkToPatch = (SubChunk subChunk, ref int addedCount, ref int removedCount, ref bool wereSelectedLines) =>
            };
            return ToPatch(subChunkToPatch);