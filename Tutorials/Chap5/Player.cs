using Altseed;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
        // コンストラクタ
        public Player(Vector2F position)
        {
            // 座標を設定
            Position = position;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 移動を実行
            Move();

            // ショットを実行
            Shot();

            // CollidableObjectのOnupdate呼び出し
            base.OnUpdate();
        }

        // 移動を行う
        private void Move()
        {
            // 現在のX座標を取得する
            var x = Position.X;
            // 現在のY座標を取得する
            var y = Position.Y;

            // ↑キーでY座標を減少
            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold)
            {
                y -= 2.5f;
            }

            // ↓キーでY座標を増加
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold)
            {
                y += 2.5f;
            }

            // →キーでX座標を増加
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold)
            {
                x += 2.5f;
            }

            // ←キーでX座標を減少
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold)
            {
                x -= 2.5f;
            }

            // テクスチャのサイズの半分を取得する
            var halfSize = Texture.Size / 2;

            // X座標が画面外に行かないように調整
            x = MathHelper.Clamp(x, Engine.WindowSize.X - halfSize.X, halfSize.X);
            // Y座標が画面外に行かないように調整
            y = MathHelper.Clamp(y, Engine.WindowSize.Y - halfSize.Y, halfSize.Y);

            // 調整された座標を設定
            Position = new Vector2F(x, y);
        }

        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                ------added start------
                Parent.AddChildNode(new PlayerBullet(Position + CenterPosition));
                ------added end------
                ------removed start------
                Parent.AddChildNode(new Bullet(Position + CenterPosition, new Vector2F(10f, 0.0f)));
                ------removed end------
            }
        }
    }
}
