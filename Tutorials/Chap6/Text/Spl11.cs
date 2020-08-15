        public Meteor(Player player, Vector2F position, Vector2F velocity) : base(player, position)
        {
            // 速度の設定
            this.velocity = velocity;

            // テクスチャの設定
            Texture = Texture2D.LoadStrict("Resources/Meteor.png");

            // 中心座標の設定
            CenterPosition = ContentSize / 2;

+           // 半径の設定
+           collider.Radius = Texture.Size.X / 2;

            // スコアの設定
            score = 1;
        }
