module "ecs_service_abeesha" {
  source  = "terraform-aws-modules/ecs/aws//modules/service"
  version = "5.2.2"

  name        = "abeesha"
  cluster_arn = module.ecs_cluster_abeesha.arn

  cpu    = 1024
  memory = 4096

  container_definitions = {
    ("abeesha") = {
      essential = true
      cpu       = 512
      memory    = 1024
      image     = module.ecr_abeesha.repository_url

      port_mappings = [
        {
          name          = "abeesha"
          containerPort = 8080
          hostPort      = 8080
          protocol      = "tcp"
        }
      ]

      readonly_root_filesystem  = false
      enable_cloudwatch_logging = false

      log_configuration = {
        logDriver = "awslogs"
        options = {
          awslogs-create-group  = "true"
          awslogs-group         = "/ecs/abeesha"
          awslogs-region        = local.region
          awslogs-stream-prefix = "ecs"
        }
      }

      memory_reservation = 100
    }
  }

  load_balancer = {
    service = {
      target_group_arn = element(module.ecs_alb_abeesha.target_group_arns, 0)
      container_name   = "abeesha"
      container_port   = 8080
    }
  }

  subnet_ids = module.vpc.private_subnets

  security_group_rules = {
    alb_ingress = {
      type                     = "ingress"
      from_port                = 8080
      to_port                  = 8080
      protocol                 = "tcp"
      source_security_group_id = module.ecs_alb_sg_abeesha.security_group_id
    }
    egress_all = {
      type        = "egress"
      from_port   = 0
      to_port     = 0
      protocol    = "-1"
      cidr_blocks = ["0.0.0.0/0"]
    }
  }
}

resource "aws_service_discovery_http_namespace" "abeesha" {
  name = "abeesha"
}

output "service_id_abeesha" {
  description = "ARN that identifies the service"
  value       = module.ecs_service_abeesha.id
}

output "service_name_abeesha" {
  description = "Name of the service"
  value       = module.ecs_service_abeesha.name
}

output "service_iam_role_name_abeesha" {
  description = "Service IAM role name"
  value       = module.ecs_service_abeesha.iam_role_name
}

output "service_iam_role_arn_abeesha" {
  description = "Service IAM role ARN"
  value       = module.ecs_service_abeesha.iam_role_arn
}

output "service_iam_role_unique_id_abeesha" {
  description = "Stable and unique string identifying the service IAM role"
  value       = module.ecs_service_abeesha.iam_role_unique_id
}

output "service_container_definitions_abeesha" {
  description = "Container definitions"
  value       = module.ecs_service_abeesha.container_definitions
}

output "service_task_definition_arn_abeesha" {
  description = "Full ARN of the Task Definition (including both `family` and `revision`)"
  value       = module.ecs_service_abeesha.task_definition_arn
}
