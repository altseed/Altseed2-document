        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = ConentSize / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // 移動速度を設定
            this.speed = speed;

            // 自身が倒された時に加算されるスコアを設定
            score = 10;
        }
