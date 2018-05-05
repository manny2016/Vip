

namespace YoVip.Core.Models
{
    public class WxBonusRule
    {
        [Newtonsoft.Json.JsonProperty("cost_money_unit")]
        public virtual decimal CostMoneyUnit{ get; set; }

        [Newtonsoft.Json.JsonProperty("increase_bonus")]
        public virtual decimal IncreaseBonus { get; set; }

        [Newtonsoft.Json.JsonProperty("max_increase_bonus")]
        public virtual decimal MaxIncreaseBonus{ get; set; }

        [Newtonsoft.Json.JsonProperty("init_increase_bonus")]
        public virtual decimal InitIncreaseBonus{ get; set; }

        [Newtonsoft.Json.JsonProperty("cost_bonus_unit")]
        public virtual decimal CostBonusUnit{ get; set; }

        [Newtonsoft.Json.JsonProperty("reduce_money")]
        public virtual decimal ReduceMoney{ get; set; }

        [Newtonsoft.Json.JsonProperty("least_money_to_use_bonus")]
        public virtual decimal LeastMoneyToUseBonus { get; set; }

        [Newtonsoft.Json.JsonProperty("max_reduce_bonus")]
        public virtual decimal MaxReduceBonus { get; set; }
        //    "bonus_rule": {
        //  "cost_money_unit": 100,
        //  "increase_bonus": 1,
        //  "max_increase_bonus": 200,
        //  "init_increase_bonus": 10,
        //  "cost_bonus_unit": 5,
        //  "reduce_money": 100,
        //  "least_money_to_use_bonus": 1000,
        //  "max_reduce_bonus": 50
        //},
    }
}
