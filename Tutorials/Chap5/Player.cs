using Altseed;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
        // ================================================================
        // 省略
        // ================================================================
    
        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
+               Parent.AddChildNode(new PlayerBullet(Position + CenterPosition));

-               Parent.AddChildNode(new Bullet(Position + CenterPosition, new Vector2F(10f, 0.0f)));
            }
        }
    }
}
