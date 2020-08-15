        public RadialShotEnemy(Player player, Vector2F position, int shotAmount) : base(player, position)
        {
            // 撃ち出すショットの個数を設定
            this.shotAmount = shotAmount;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // スコアを設定
            score = 30;
        }

        // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
+            Parent.AddChildNode(new EnemyBullet(mainNode, Position, velocity));
-            Parent.AddChildNode(new EnemyBullet(Position, velocity));
        }
